# deploy gRPC service to Kubernetes

    This example demonstrates step by step to deploy and access gRPC service to Kubernetes in Azure (aks)

## Prerequisites

1. You have an Azure Subscription. [Free $200 Azure Credit](https://azure.microsoft.com/free)
1. You have an image repository (this example used Azure container registry)
3. Your gRPC service docker image is pushed to Azure Container registry(ACR) [Push your image to ACR](https://docs.microsoft.com/en-us/azure/container-registry/container-registry-get-started-docker-cli) 

### Step 1: `Create` Azure kubernetes Cluster 

1. Create Azure kubernetes Cluster
