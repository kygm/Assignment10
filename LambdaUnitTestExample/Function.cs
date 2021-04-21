using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LambdaUnitTestExample
{
    public enum Condition
    {
        EXCELLENT,
        GOOD,
        FAIR,
        BAD
    }
    public class Car
    {
        public int Speed
        {
            get => PrivSpeed;
            set
            {
                if ((value > 200))
                {
                    PrivSpeed = 200;
                }
                else if ((value < -50))
                {
                    PrivSpeed = -50;
                }
                else
                {
                    PrivSpeed = value;
                }
            }
        }
        public string Make;
        public Condition Condition;
        private int PrivSpeed;

        public Car()
        {

            Make = "";
            Speed = PrivSpeed;
        }
        public Car(String m, Condition c)
        {
            Make = m;
            Condition = c;
        }
    }
    public class Functions
    {

        public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK, //(200)
            };

            return response;
        }
    }
}
