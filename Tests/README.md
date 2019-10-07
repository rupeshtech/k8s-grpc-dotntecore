# Using grpcurl

    This example demonstrates step by step to  test grpc service using grpcurl

### grpcurl 
grpcurl is a command-line tool that lets you interact with gRPC servers. **It's basically curl for gRPC servers.**

The main purpose for this tool is to invoke RPC methods on a gRPC server from the command-line. gRPC servers use a binary encoding on the wire (protocol buffers, or "protobufs" for short). So they are basically impossible to interact with using regular curl (and older versions of curl that do not support HTTP/2 are of course non-starters).

Download grpcurl tool from https://github.com/fullstorydev/grpcurl/releases


#### testing grpc server running locally (in Docker)

See images attached below to see the responses of grpcurl requests

1. create container

```sh
d container run -p 82:50051 samplegrpcservice -d
```

2. list service

```sh
grpcurl localhost:50051 list
```
if you get error **Failed to dial target host "localhost:50051": tls: first record does not look like a TLS handshake** the either  configure https certiticate for your grpc service or use **-plaintext** to ignore handshake error

```sh
grpcurl -plaintext localhost:50051 list
```
3. list methods

```sh
grpcurl -plaintext localhost:50051 list Services.Calculator
```
4. descibe method

```sh
grpcurl -plaintext localhost:50051 describe  Services.Calculator.AddNumbers
```
5. invoke method

```sh
grpcurl -plaintext -d '{"firstNumber":5,"secondNumber":3}' localhost:50051   Services.Calculator/AddNumbers
```

#### testing grpc server running in Azure Kubernetes Cluster (aks)

To see the step-by-step guide to deploy grpc service in aks. [how to setup aks](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/k8s-manifests/README.md)


1. list service

```sh
grpcurl localhost:50051 list
```
if you get error **Failed to dial target host "localhost:50051": tls: first record does not look like a TLS handshake** the either  configure https certiticate for your grpc service or use **-plaintext** to ignore handshake error

```sh
grpcurl -insecure localhost:50051 list
```
2. list methods

```sh
grpcurl -insecure localhost:50051 list Services.Calculator
```
3. descibe method

```sh
grpcurl -insecure localhost:50051 describe  Services.Calculator.AddNumbers
```
4. invoke method

```sh
grpcurl -insecure -d '{"firstNumber":5,"secondNumber":3}' localhost:50051   Services.Calculator/AddNumbers
```

#### Trouble shooting

Server Reflection error: If you are getting error: Failed to list services: server does not support the reflection API

then add in services folder. [ReflectionImplementation](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/SampleGrpcService/Services/ReflectionImplementation.cs)
```sh
public class ReflectionImplementation : ReflectionServiceImpl
    {
        public ReflectionImplementation() : base(Calculator.Descriptor, Greeter.Descriptor, ServerReflection.Descriptor)
        {
        }

    }
```
and  in program.cs [program.cs](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/SampleGrpcService/Program.cs)
```sh
endpoints.MapGrpcService<ReflectionImplementation>();
```

#### Screenshots
![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/test_aks.PNG)
![alt text](https://github.com/rupeshtech/k8s-grpc-dotntecore/blob/master/screenshots/vs_16.PNG)