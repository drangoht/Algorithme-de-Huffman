import { useState } from "react";
import { EncodeResponse } from "../../dtos/Encode/EncodeResponse";
import { WeightedGraph } from "../../dtos/WeightedGraph";
import { Character } from "../../dtos/Character";
import TextToEncodeForm from "./TextToEncodeForm";
import SizeStats from "./SizeStats";
import BinaryHuffman from "./BinaryHuffman";
import MatchingTable from "./MatchingTable";
import Tree from "./Tree";
import { apiPost } from "../../utils/apiClient";

const Encode = () => {
  const [binaryHuffman, setBinaryHuffman] = useState("");
  const [chars, setChars] = useState<Character[]>([]);
  const [encodedSize, setEncodedSize] = useState(0);
  const [originalSize, setOriginalSize] = useState(0);
  const [graph, setGraph] = useState<WeightedGraph>();

  async function onEncodeText(textToEncode: string) {
    try {
      const responseEncoded = await apiPost<EncodeResponse>("/huffman/encode", {
        textToEncode,
      });

      setEncodedSize(responseEncoded.encodedSize);
      setOriginalSize(responseEncoded.originalSize);
      setGraph(responseEncoded.graph);
      setBinaryHuffman(responseEncoded.encodedBinaryString);

      const newChars = responseEncoded.matchingCharacters.map((chr) => ({
        id: chr.id,
        value: chr.value,
      }));
      setChars(newChars);
    } catch (error) {
      console.log(error);
      throw error;
    }
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
