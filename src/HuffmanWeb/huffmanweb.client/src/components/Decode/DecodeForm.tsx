import React, { useState, FormEvent } from "react";
import { DecodeFormProps } from "../../Interfaces/Decode/DecodeFormProps";
import { Character } from "../../dtos/Character";
import { useTextareaForm } from "../../hooks/useTextareaForm";
import FormTextarea from "../UI/FormTextarea";

const DecodeForm: React.FC<DecodeFormProps> = (props) => {
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
      props.onDecode(binaryHuffmanForm.value, matchingCharacters);
    } catch (e) {
      setCharactersError(true);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <FormTextarea
        label="Veuillez saisir le texte binaire à decoder:"
        value={binaryHuffmanForm.value}
        onChange={binaryHuffmanForm.handleChange}
        cols={75}
        rows={10}
      />
      <FormTextarea
        label="Veuillez saisir la table de correspondance au format JSON:"
        value={matchingCharactersForm.value}
        onChange={matchingCharactersForm.handleChange}
        cols={75}
        rows={10}
        error={
          charactersError
            ? "Le format de la table de correspondance ne convient pas !!"
            : undefined
        }
      />
      <button type="submit">Decoder</button>
    </form>
  );
};

export default DecodeForm;
