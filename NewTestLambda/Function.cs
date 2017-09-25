using System;
using System.IO;
using System.Text;

using Newtonsoft.Json;

using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using System.Collections;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace NewTestLambda
{
    public class Function
    {
        private static readonly JsonSerializer _jsonSerializer = new JsonSerializer();
        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient();

        public async Task<Amazon.DynamoDBv2.DocumentModel.Document> FunctionHandler()
        {
            Table myDynamoTable = Table.LoadTable(client, "myDynamoTable");
            Document itemDocument = await myDynamoTable.GetItemAsync(3);
            return itemDocument;
        }

    }
}