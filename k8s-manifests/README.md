# deploy gRPC service to Kubernetes

    This example demonstrates step by step to deploy and access gRPC service to Kubernetes in Azure (aks)

## Prerequisites

1. You have an Azure Subscription. [Free $200 Azure Credit](https://azure.microsoft.com/free)
1. You have an image repository (this example used Azure container registry)
3. Your gRPC service docker image is pushed to Azure Container registry(ACR) [Push your image to ACR](https://docs.microsoft.com/en-us/azure/container-registry/container-registry-get-started-docker-cli) 

### Steps 

1. Create Azure kubernetes Cluster

```sh
az aks create -g <resourceGroupName> --name <kubernetes-cluster-name>  --service-principal <servicePrincipalId> --client-secret <clientSecret>
```
2. Create a public (static) IP address in the resource group MC_resourceGroupName_location and note the dns name
3. Configure the route traffic to the ingress controller

```sh
helm install stable/nginx-ingress \
    --namespace ingress-basic \
    --set controller.replicaCount=1 \
	--set controller.image.repository= quay.io/kubernetes-ingress-controller/nginx-ingress-controller  \
    --set controller.service.loadBalancerIP="<your Ip address>"
```
4. Configure a DNS name:
For the HTTPS certificates to work correctly, configure an FQDN for the ingress controller IP address. Update the following script with the IP address of your ingress controller and a unique name that you would like to use for the FQDN: (This step is not always necessay but good to be sure)
```sh
# Public IP address of static ip address
IP="<your static IP>"

# Name to associate with public IP address
DNSNAME="<dns name>"

# Get the resource-id of the public ip
PUBLICIPID=$(az network public-ip list --query "[?ipAddress!=null]|[?contains(ipAddress, '$IP')].[id]" --output tsv)

# Update public ip address with DNS name
az network public-ip update --ids $PUBLICIPID --dns-name $DNSNAME
```
5. Create `secret` to pull image

```sh
kubectl create secret docker-registry <secret-name> --docker-server=<youracr.azurecr.io> --docker-username=<acrusername> --docker-password=<acr-password> --docker-email=<youremailaddress>
```
6. Create `certificate` 

```sh
kubectl apply -f https://raw.githubusercontent.com/jetstack/cert-manager/release-0.6/deploy/manifests/00-crds.yaml
```

```sh
helm install stable/cert-manager \
    --name cert-manager \
    --namespace kube-system \
    --set ingressShim.extraArgs='{--default-issuer-name=letsencrypt-prod,--default-issuer-kind=Issuer}' \
    --set rbac.create=false
```

```sh
kubectl apply -f cert-issuer.yaml
```

```sh
kubectl apply -f certificates.yaml
```
### Note: 
If you get helm or tiller related error then run followin script and repeated step 6

```
kubectl create serviceaccount --namespace kube-system tiller
kubectl create clusterrolebinding tiller-cluster-rule --clusterrole=cluster-admin --serviceaccount=kube-system:tiller
kubectl patch deploy --namespace kube-system tiller-deploy -p '{"spec":{"template":{"spec":{"serviceAccount":"tiller"}}}}'

helm init
```

7. **Kubernetes `ingress`**

```sh
kubectl create -f ingress.yaml
```
    A few things to note:

    We've tagged the ingress with the annotation nginx.ingress.kubernetes.io/backend-protocol: "GRPC". This is the magic ingredient that sets up the appropriate nginx configuration to route http/2 traffic to our service.

8. **Kubernetes `deployment`**

```sh
kubectl create -f app-deployment.yaml
```
9. **Kubernetes `service`**

```sh
kubectl create -f app-service.yaml
```

9. **Check `deployment, services and pods`**

you can run following commands to check deployment, services and pods

```yml
kubectl get ing -n ingress-basic
```
```yml
kubectl get deployment
```
```yml
kubectl get pods
```
```yml
kubectl logs <pod_name> -f
```

### Notes

> Why grpc is not working (as of now) of Azure Appservice (for windows and linux both) https://github.com/grpc/grpc-dotnet/issues/578, aspnet/AspNetCore#9020 (comment)