import React, { FormEvent } from "react";
import { TextToEncodeFormProps } from "../../Interfaces/Encode/TextToEncodeFormProps";
import { useTextareaForm } from "../../hooks/useTextareaForm";
import FormTextarea from "../UI/FormTextarea";

const TextToEncodeForm: React.FC<TextToEncodeFormProps> = (props) => {
  const { value, handleChange } = useTextareaForm("");

  const handleSubmit = (event: FormEvent) => {
    event.preventDefault();
    props.onEncodeText(value);
  };

  return (
    <form onSubmit={handleSubmit}>
      <FormTextarea
        label="Veuillez saisir le texte à encoder:"
        value={value}
        onChange={handleChange}
        cols={75}
        rows={10}
      />
      <button type="submit">Encoder</button>
    </form>
  );
};

export default TextToEncodeForm;
