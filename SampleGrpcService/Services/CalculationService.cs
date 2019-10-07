using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleGrpcService.Services
{
    public class CalculationService:Calculator.CalculatorBase
    {
        private readonly ILogger<CalculationService> _logger;
        public CalculationService(ILogger<CalculationService> logger)
        {
            _logger = logger;
        }

        public override Task<CalculationResponse> AddNumbers(InputNumbers request, ServerCallContext context)
        {
            return Task.FromResult(new CalculationResponse
            {
                Response = "Numbers added successfully.",
                Result = request.FirstNumber + request.SecondNumber
            }); ; ;
        }

        public override Task<CalculationResponse> MultiplyNumbers(InputNumbers request, ServerCallContext context)
        {
            return Task.FromResult(new CalculationResponse
            {
                Response = "Numbers multiplied successfully.",
                Result = request.FirstNumber * request.SecondNumber
            }); ; ;
        }
    }
}
