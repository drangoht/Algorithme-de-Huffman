import React, { useState, FormEvent } from "react";
import { TextToEncodeFormProps } from "../../Interfaces/Encode/TextToEncodeFormProps";

const TextToEncodeForm: React.FC<TextToEncodeFormProps> = (props) => {
  const [textareaValue, setTextareaValue] = useState("");

  const handleTextareaChange = (
    event: React.ChangeEvent<HTMLTextAreaElement>,
  ) => {
    setTextareaValue(event.target.value);
  };

  const handleSubmit = (event: FormEvent) => {
    event.preventDefault();
    props.onEncodeText(textareaValue);
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Veuillez saisir le texte à encoder:
        <textarea
          cols={75}
          rows={10}
          value={textareaValue}
          onChange={handleTextareaChange}
        />
      </label>
      <button type="submit">Encoder</button>
    </form>
  );
};

export default TextToEncodeForm;
