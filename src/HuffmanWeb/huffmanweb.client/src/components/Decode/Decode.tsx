import { useState } from "react";
import { Alert, Collapse } from "@mui/material";
import { DecodeResponse } from "../../dtos/Decode/DecodeResponse";
import DecodeForm from "./DecodeForm";
import DecodedText from "./DecodedText";
import { Character } from "../../dtos/Character";
import { apiPost } from "../../utils/apiClient";

const Decode = () => {
  const [decodedText, setDecodedText] = useState("");
  const [textNotFound, setTextNotFound] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [hasError, setHasError] = useState(false);

  async function onDecode(
    binaryHuffman: string,
    matchingCharacters: Character[],
  ) {
    setIsLoading(true);
    setHasError(false);
    try {
      const responseEncoded = await apiPost<DecodeResponse>("/huffman/decode", {
        binaryHuffman,
        matchingCharacters,
      });
      setDecodedText(responseEncoded.decodedText);
      setTextNotFound(responseEncoded.decodedText === "");
    } catch {
      setHasError(true);
    } finally {
      setIsLoading(false);
    }
  }

  return (
    <>
      <DecodeForm onDecode={onDecode} isLoading={isLoading} />
      <Collapse in={hasError}>
        <Alert severity="error" sx={{ mb: 2 }}>
          Une erreur est survenue lors du décodage. Vérifiez le serveur.
        </Alert>
      </Collapse>
      <DecodedText decodedText={decodedText} textNotFound={textNotFound} />
    </>
  );
};

export default Decode;
