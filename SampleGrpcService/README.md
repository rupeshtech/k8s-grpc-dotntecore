# gRPC Server in .NET Core

    This example demonstrates step by step to create, run and consume a gRPC service in .NetCore 3.0

## Prerequisites

1. You have a latest version of Visual studio.
2. You have a .NET Core 3.0 installed.
3. Its good to have Visual Studio Code.

### Step 1: `Create` gRPC Project 

1. Create a gRPC service using default template of Visual Studio
2. Rename greet.proto to services.proto , also change the package name - optional
3. Register new service "Calculator" in services.proto - optional
4. Build Project.
5. Add a new service CalculationService in Services Folder.- optional
6. Register new service in Starup.cs (onlt needed if steps 3 and 4 are performed)
7. Configure Kestrel Program.cs to listen on port 50051
7. Also configure Certificate - optional

Instead of creating and setting up new gRPC project, you can use project in this repo. So Downlaod and run 
[SampleGrpcService](https://github.com/rupeshtech/k8s-grpc-dotntecore/tree/master/SampleGrpcService)

> See also Microsoft Documentation: https://docs.microsoft.com/en-us/aspnet/core/grpc/aspnetcore?view=aspnetcore-3.0&tabs=visual-studio
> See also kerstel Webserver implementation : https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-3.0

![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/vs_1.PNG)
![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/vs_2.PNG)
![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/vs_3.PNG)
![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/vs_4.PNG)
![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/vs_5.PNG)
![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/vs_6.PNG)
![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/vs_7.PNG)
![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/vs_8.PNG)
![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/vs_9.PNG)
![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/vs_10.PNG)
![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/vs_11.PNG)
![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/vs_11.1.PNG)
![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/vs_13.PNG)

