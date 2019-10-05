# gRPC

    This example demonstrates step by step to create, run, deploy and  consume a gRPC service in .NetCore 3.0
    Whole process is has been categarized in 3 main section **Create, Test and Deploy**

## Prerequisites

1. You have a latest version of Visual studio.
2. You have a .NET Core 3.0 installed.
3. Its good to have Visual Studio Code.
4. You have an Azure Subscription. [Free $200 Azure Credit](https://azure.microsoft.com/free)
5. You have an image repository (this example used Azure container registry)


### Step 1: `Create` gRPC Service 

1. Create a gRPC service using default template of Visual Studio
2. Add a Service (named CalculationService)
3. Register reflection in Startup.cs (install Nuget Grpc.Reflection) 

For very detailed explanation of visit
[how to setup gRPC server in .NET](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/SampleGrpcService/README.md)

The sample application
[SampleGrpcService](https://github.com/rupeshtech/k8s-grpc-dotntecore/tree/master/SampleGrpcService)

### Step 2: `Test` gRPC Service

To test gRPC service, we'll use the grpcurl utility:
1. Download [grpculy utiltiy](https://github.com/fullstorydev/grpcurl/releases)
2. Run following commands

# list services
grpcurl servername:port list  (for ex: grpcurl localhost:50051 list )

# list methods
grpcurl servername:port list packagename.servicename (for ex: grpcurl localhost:50051 list Services.Calculator)

# describe method
grpcurl servername:port describe packagename.servicename.MethodName (for ex: grpcurl localhost:50051 describe  Services.Calculator.AddNumbers)

# Invoke method
grpcurl -d '{requestbody}' servername:port packagename.servicename.MethodName (for ex: grpcurl -d '{"firstNumber":5,"secondNumber":3}' localhost:50051   Services.Calculator/AddNumbers)

if you are getting error: Failed to dial target host "sever": tls: first record does not look like a TLS handshake
then add **-plaintext** if your host name is **localhost** or use **-insecure**

For very detailed explanation of visit
[how to setup gRPC server in .NET](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/SampleGrpcService/README.md)

The sample application
[SampleGrpcService](https://github.com/rupeshtech/k8s-grpc-dotntecore/tree/master/SampleGrpcServ)

![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/vs_16.PNG)

### Step 3: `Deploy` to kubernetes

Deploy to Aks
For step by step detail 
[how to setup aks](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/k8s-manifests/README.md)

kubernetes configs
[yaml files](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/k8s-manifests)


### Notes

