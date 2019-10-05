using Grpc.Reflection;
using Grpc.Reflection.V1Alpha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleGrpcService.Services
{
    public class ReflectionImplementation : ReflectionServiceImpl
    {
        public ReflectionImplementation() : base(Calculator.Descriptor, Greeter.Descriptor, ServerReflection.Descriptor)
        {
        }

    }
}
