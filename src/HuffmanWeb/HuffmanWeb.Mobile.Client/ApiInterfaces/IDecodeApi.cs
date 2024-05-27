using HuffmanWeb.Common.DTOs.Requests;
using HuffmanWeb.Common.DTOs.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanWeb.Mobile.Client.ApiInterfaces
{
    public interface IDecodeApi
    {
        [Post("/huffman/decode")]
        DecodeResponse Decode(DecodeRequest request);
    }
}
