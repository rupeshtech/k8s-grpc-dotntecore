# gRPC

    This example demonstrates step by step to create, run, deploy and  consume a gRPC service in .NetCore 3.0.
    Whole process is has been categorized in 3 main section **Create, Test and Deploy**.

## Detailed explanation for each step

There are seperate(detailed) document for each process **describing step by step(from scratch)**. Each document starts for scratch till end. So read each steps carefully
Detailed document for:

1. [How to Create](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/SampleGrpcService/README.md) grpc in C# (.NET Core 3.0)
2. [How to Test](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/Tests/README.md) using grpcurl
3. [How to Deploy](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/k8s-manifests/README.md) in Azure Kubernetes (aks)

## Prerequisites

1. You have a latest version of Visual studio.
2. You have a .NET Core 3.0 installed.
3. Its good to have Visual Studio Code.
4. You have an Azure Subscription. [Free $200 Azure Credit](https://azure.microsoft.com/free)
5. You have an image repository (this example used Azure container registry)

## Step 1: `Create` gRPC Service 

1. Create a gRPC service using default template of Visual Studio
2. Add a Service (named CalculationService)
3. Register reflection in Startup.cs (install Nuget Grpc.Reflection) 

For very detailed explanation of visit
[how to setup gRPC server in .NET](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/SampleGrpcService/README.md)

The sample application
[SampleGrpcService](https://github.com/rupeshtech/k8s-grpc-dotntecore/tree/master/SampleGrpcService)


## Step 2: `Deploy` to kubernetes

Deploy to Aks
For step by step explanation on [how to setup aks](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/k8s-manifests/README.md)

kubernetes configs
[yaml files](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/k8s-manifests)

## Step 3: `Test` gRPC Service

To test gRPC service, we'll use the grpcurl utility:
1. Download [grpculy utiltiy](https://github.com/fullstorydev/grpcurl/releases)
2. Run following commands

### **list services**
```sh
grpcurl servername:port list  (for ex: grpcurl localhost:50051 list )
```
### **list methods**
```sh
grpcurl servername:port list packagename.servicename (for ex: grpcurl localhost:50051 list Services.Calculator)
```
### **describe method**
```sh
grpcurl servername:port describe packagename.servicename.MethodName (for ex: grpcurl localhost:50051 describe  Services.Calculator.AddNumbers)
```

### **invoke method**
```sh
grpcurl -d '{requestbody}' servername:port packagename.servicename.MethodName (for ex: grpcurl -d '{"firstNumber":5,"secondNumber":3}' localhost:50051   Services.Calculator/AddNumbers)
```
For detailed explanation and troubleshotting [grpcurl](https://github.com/rupeshtech/k8s-grpc-dotntecore/tree/master/Tests)

### Notes

> Github grpc project https://github.com/grpc/grpc/tree/master/src/csharp

> grpcurl https://github.com/fullstorydev/grpcurl

> Why grpc service cannot be deployed on Azure Appservice (for windows and linux both) https://github.com/grpc/grpc-dotnet/issues/578, https://github.com/aspnet/AspNetCore/issues/9020#issuecomment-479600486

