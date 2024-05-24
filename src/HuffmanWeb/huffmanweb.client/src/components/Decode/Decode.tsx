import { useState } from "react";
import { DecodeResponse } from "../../dtos/Decode/DecodeResponse";
import DecodeForm from "./DecodeForm";
import DecodedText from "./DecodedText";
import { Character } from "../../dtos/Character";

const Decode = () => {
  let responseEncoded: DecodeResponse;
  const [decodedText, setDecodedText] = useState("");
  const [textNotFound, setTextNotFound] = useState(false);
  async function onDecode(
    binaryHuffman: string,
    matchingCharacters: Character[],
  ) {
    const form = new FormData();
    form.append("binaryHuffman", binaryHuffman);
    form.append("matchingCharacters", JSON.stringify(matchingCharacters));
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
        responseEncoded.decodedText == ""
          ? setTextNotFound(true)
          : setTextNotFound(false);
      })
      .catch((error: Error) => {
        console.log(error);
        throw error;
      });
  }

  return (
    <>
      <DecodeForm onDecode={onDecode} />
      <DecodedText decodedText={decodedText} textNotFound={textNotFound} />
    </>
  );
};

export default Decode;
