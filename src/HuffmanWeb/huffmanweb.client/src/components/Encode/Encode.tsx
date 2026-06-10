import { useState } from "react";
import { Alert, Collapse } from "@mui/material";
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
  const [isLoading, setIsLoading] = useState(false);
  const [hasError, setHasError] = useState(false);

  async function onEncodeText(textToEncode: string) {
    setIsLoading(true);
    setHasError(false);
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
    } catch {
      setHasError(true);
    } finally {
      setIsLoading(false);
    }
  }

  return (
    <>
      <TextToEncodeForm onEncodeText={onEncodeText} isLoading={isLoading} />
      <Collapse in={hasError}>
        <Alert severity="error" sx={{ mb: 2 }}>
          Une erreur est survenue lors de l'encodage. Vérifiez le serveur.
        </Alert>
      </Collapse>
      <SizeStats encodedSize={encodedSize} originalSize={originalSize} />
      <BinaryHuffman binaryHuffman={binaryHuffman} />
      <MatchingTable characters={chars} />
      <Tree graph={graph!} />
    </>
  );
};

export default Encode;
