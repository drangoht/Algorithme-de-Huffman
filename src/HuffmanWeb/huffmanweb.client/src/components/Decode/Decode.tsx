import { useState } from "react";
import { DecodeResponse } from "../../dtos/Decode/DecodeResponse";
import { Character } from "../../dtos/Character";
import DecodeForm from "./DecodeForm";
import DecodedText from "./DecodedText";

const Decode = () => {
  let responseEncoded: DecodeResponse;
  const [decodedText, setDecodedText] = useState("");

  async function onDecode(
    binaryHuffman: string,
    matchingCharacters: Character[],
  ) {
    const form = new FormData();
    form.append("binaryHuffman", binaryHuffman);
    form.append("matchingCharacters", matchingCharacters);
    await fetch("/huffman/decode", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        binaryHuffman: binaryHuffman,
        matchingCharacters: matchingCharacters,
      }),
    })
      .then(async (response) => {
        if (!response.ok) {
          throw new Error(response.statusText);
        }
        responseEncoded = await response.json();
          setDecodedText(responseEncoded.decodedText);
      })
      .catch((error: Error) => {
        console.log(error);
        throw error;
      });
  }

  return (
    <>
      <DecodeForm onDecode={onDecode} />
      <DecodedText decodedText={decodedText} />
    </>
  );
};

export default Decode;
