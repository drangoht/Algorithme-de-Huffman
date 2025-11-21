import { useState } from "react";
import { DecodeResponse } from "../../dtos/Decode/DecodeResponse";
import DecodeForm from "./DecodeForm";
import DecodedText from "./DecodedText";
import { Character } from "../../dtos/Character";
import { apiPost } from "../../utils/apiClient";

const Decode = () => {
  const [decodedText, setDecodedText] = useState("");
  const [textNotFound, setTextNotFound] = useState(false);

  async function onDecode(
    binaryHuffman: string,
    matchingCharacters: Character[],
  ) {
    try {
      const responseEncoded = await apiPost<DecodeResponse>("/huffman/decode", {
        binaryHuffman,
        matchingCharacters,
      });

      setDecodedText(responseEncoded.decodedText);
      setTextNotFound(responseEncoded.decodedText === "");
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  return (
    <>
      <DecodeForm onDecode={onDecode} />
      <DecodedText decodedText={decodedText} textNotFound={textNotFound} />
    </>
  );
};

export default Decode;
