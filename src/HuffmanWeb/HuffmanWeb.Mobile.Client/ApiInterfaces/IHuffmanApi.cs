using HuffmanWeb.Common.DTOs.Requests;
using HuffmanWeb.Common.DTOs.Responses;
using Refit;

namespace HuffmanWeb.Mobile.Client.ApiInterfaces
{
    public interface IHuffmanApi
    {
        [Post("/huffman/encode")]
        Task<EncodeResponse> Encode([Body] EncodeRequest req);

        [Post("/huffman/decode")]
        Task<DecodeResponse> Decode([Body] DecodeRequest req);
    }
}
