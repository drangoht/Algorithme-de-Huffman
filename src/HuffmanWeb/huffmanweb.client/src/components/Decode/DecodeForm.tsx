import React, { useState, FormEvent } from "react";
import { DecodeFormProps } from "../../Interfaces/Decode/DecodeFormProps";
import { Character } from "../../dtos/Character";
const DecodeForm: React.FC<DecodeFormProps> = (props) => {
  const [binaryHuffman, setBinaryHuffman] = useState(
    "11101111110000001010011100110101",
  );
  const [matchingCharactersJson, setmatchingCharactersJson] = useState(
    '[{"id":"!","value":"101"},{"id":" ","value":"110"},{"id":"t","value":"1111"},{"id":"I","value":"1110"},{"id":"s","value":"100"},{"id":"o","value":"001"},{"id":"r","value":"010"},{"id":"W","value":"000"},{"id":"k","value":"011"}]',
  );

  const handleBinaryHuffmanChange = (
    event: React.ChangeEvent<HTMLTextAreaElement>,
  ) => {
    setBinaryHuffman(event.target.value);
  };

  const handlematchingCharactersJsonChange = (
    event: React.ChangeEvent<HTMLTextAreaElement>,
  ) => {
    setmatchingCharactersJson(event.target.value);
  };

  const handleSubmit = (event: FormEvent) => {
    event.preventDefault();
    let matchingCharacters: Character[] = JSON.parse(matchingCharactersJson);
    props.onDecode(binaryHuffman, matchingCharacters);
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Veuillez saisir le texte binaire à decoder:
        <textarea
          cols={75}
          rows={10}
          value={binaryHuffman}
          onChange={handleBinaryHuffmanChange}
        />
      </label>
      <label>
        Veuillez saisir la table de correspondance au format JSON:
        <textarea
          cols={75}
          rows={10}
          value={matchingCharactersJson}
          onChange={handlematchingCharactersJsonChange}
        />
      </label>
      <button type="submit">Decoder</button>
    </form>
  );
};

export default DecodeForm;
