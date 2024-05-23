import { useState } from "react";
import { EncodeResponse } from "../../dtos/Encode/EncodeResponse";
import { WeightedGraph } from "../../dtos/WeightedGraph";
import { Character } from "../../dtos/Character";
import TextToEncodeForm from "./TextToEncodeForm";
import SizeStats from "./SizeStats";
import BinaryHuffman from "./BinaryHuffman";
import MatchingTable from "./MatchingTable";
import Tree from "./Tree";

const Encode = () => {
  let responseEncoded: EncodeResponse;
  const [binaryHuffman, setBinaryHuffman] = useState("");
  const [chars, setChars] = useState<Character[]>([]);
  const [encodedSize, setEncodedSize] = useState(0);
  const [originalSize, setOriginalSize] = useState(0);
  const [graph, setGraph] = useState<WeightedGraph>();

  async function onEncodeText(textToEncode: string) {
    const form = new FormData();
    form.append("textToEncode", textToEncode);
    await fetch("/huffman/encode", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ textToEncode: textToEncode }),
    })
      .then(async (response) => {
        if (!response.ok) {
          throw new Error(response.statusText);
        }
        responseEncoded = await response.json();
        setEncodedSize(responseEncoded.encodedSize);
        setOriginalSize(responseEncoded.originalSize);
        setGraph(responseEncoded.graph);
        setBinaryHuffman(responseEncoded.encodedBinaryString);

        responseEncoded.matchingCharacters.forEach(function (chr) {
          chars.push({ id: chr.id, value: chr.value });
        });
        setChars(chars);
      })
      .catch((error: Error) => {
        console.log(error);
        throw error;
      });
  }

  return (
    <>
      <TextToEncodeForm onEncodeText={onEncodeText} />
      <SizeStats encodedSize={encodedSize} originalSize={originalSize} />
      <BinaryHuffman binaryHuffman={binaryHuffman} />
      <MatchingTable characters={chars} />
      <Tree graph={graph!} />
    </>
  );
};

export default Encode;
