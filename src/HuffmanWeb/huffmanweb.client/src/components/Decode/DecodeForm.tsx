import React, { useState, FormEvent } from "react";
import { Button, CircularProgress } from "@mui/material";
import LockOpenRoundedIcon from "@mui/icons-material/LockOpenRounded";
import { DecodeFormProps } from "../../Interfaces/Decode/DecodeFormProps";
import { Character } from "../../dtos/Character";
import { useTextareaForm } from "../../hooks/useTextareaForm";
import FormTextarea from "../UI/FormTextarea";

const DecodeForm: React.FC<DecodeFormProps> = ({ onDecode, isLoading }) => {
  const binaryHuffmanForm = useTextareaForm("11101111110000001010011100110101");
  const matchingCharactersForm = useTextareaForm(
    '[{"id":"!","value":"101"},{"id":" ","value":"110"},{"id":"t","value":"1111"},{"id":"I","value":"1110"},{"id":"s","value":"100"},{"id":"o","value":"001"},{"id":"r","value":"010"},{"id":"W","value":"000"},{"id":"k","value":"011"}]',
  );
  const [charactersError, setCharactersError] = useState(false);

  const handleSubmit = (event: FormEvent) => {
    event.preventDefault();
    try {
      const matchingCharacters: Character[] = JSON.parse(
        matchingCharactersForm.value,
      );
      setCharactersError(false);
      onDecode(binaryHuffmanForm.value, matchingCharacters);
    } catch {
      setCharactersError(true);
    }
  };

  return (
    <form onSubmit={handleSubmit} style={{ marginBottom: 8 }}>
      <FormTextarea
        label="Texte binaire à décoder"
        value={binaryHuffmanForm.value}
        onChange={binaryHuffmanForm.handleChange}
        cols={75}
        rows={6}
      />
      <FormTextarea
        label="Table de correspondance (JSON)"
        value={matchingCharactersForm.value}
        onChange={matchingCharactersForm.handleChange}
        cols={75}
        rows={6}
        error={
          charactersError
            ? "Format JSON invalide — vérifiez la table de correspondance"
            : undefined
        }
      />
      <Button
        type="submit"
        variant="contained"
        disabled={isLoading}
        endIcon={isLoading
          ? <CircularProgress size={16} color="inherit" />
          : <LockOpenRoundedIcon />
        }
        sx={{ mt: 0.5 }}
      >
        {isLoading ? "Décodage…" : "Décoder"}
      </Button>
    </form>
  );
};

export default DecodeForm;
