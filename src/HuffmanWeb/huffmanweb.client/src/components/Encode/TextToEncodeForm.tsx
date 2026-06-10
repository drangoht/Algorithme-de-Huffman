import React, { FormEvent } from "react";
import { Button, CircularProgress } from "@mui/material";
import ArrowForwardRoundedIcon from "@mui/icons-material/ArrowForwardRounded";
import { TextToEncodeFormProps } from "../../Interfaces/Encode/TextToEncodeFormProps";
import { useTextareaForm } from "../../hooks/useTextareaForm";
import FormTextarea from "../UI/FormTextarea";

const TextToEncodeForm: React.FC<TextToEncodeFormProps> = ({ onEncodeText, isLoading }) => {
  const { value, handleChange } = useTextareaForm("");

  const handleSubmit = (event: FormEvent) => {
    event.preventDefault();
    onEncodeText(value);
  };

  return (
    <form onSubmit={handleSubmit} style={{ marginBottom: 8 }}>
      <FormTextarea
        label="Texte à encoder"
        value={value}
        onChange={handleChange}
        cols={75}
        rows={8}
      />
      <Button
        type="submit"
        variant="contained"
        disabled={isLoading || !value.trim()}
        endIcon={isLoading
          ? <CircularProgress size={16} color="inherit" />
          : <ArrowForwardRoundedIcon />
        }
        sx={{ mt: 0.5 }}
      >
        {isLoading ? "Encodage…" : "Encoder"}
      </Button>
    </form>
  );
};

export default TextToEncodeForm;
