using HuffmanWeb.Common.DTOs.Requests;
using HuffmanWeb.Common.DTOs.Responses;
using Refit;

namespace HuffmanWeb.Mobile.Client.ApiInterfaces
{
    public interface IHuffmanApi
    {

        [Post("/encode")]
        Task<EncodeResponse> Encode([Body] EncodeRequest req);

        [Post("/decode")]
        Task<DecodeResponse> Decode([Body] DecodeRequest req);
    }
}
