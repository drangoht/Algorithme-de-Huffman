import { Button, Tooltip } from "@mui/material";
import { BinaryHuffmanProps } from "../Interfaces/BinaryHuffmanProps";
import ContentCopyRoundedIcon from "@mui/icons-material/ContentCopyRounded";
import { useState } from "react";
const BinaryHuffman = ({ binaryHuffman }: BinaryHuffmanProps) => {
  const [textCopiedSuccess, setCopiedSuccess] = useState("");

  const handleCopyTextToCLipboard = () => {
    navigator.clipboard.writeText(binaryHuffman);
    setTimeout(disabledCopiedSuccess, 1000);
    setCopiedSuccess("Copié");
  };
  const disabledCopiedSuccess = () => {
    setCopiedSuccess("");
  };
  return (
    <details>
      <summary>Résultat binaire</summary>
      <div>
        <div className="notice">
          <div className="right-action">
            {textCopiedSuccess === "" ? (
              <Tooltip title="Copier">
                <Button onAnimationEnd={handleCopyTextToCLipboard}>
                  <ContentCopyRoundedIcon />
                </Button>
              </Tooltip>
            ) : (
              <span className="copy-success"> {textCopiedSuccess}</span>
            )}
          </div>
                  <div className="binary-huffman">{binaryHuffman}</div>
        </div>
      </div>
    </details>
  );
};
export default BinaryHuffman;
