import { Button, Tooltip } from "@mui/material";
import { BinaryHuffmanProps } from "../../Interfaces/Encode/BinaryHuffmanProps";
import ContentCopyRoundedIcon from "@mui/icons-material/ContentCopyRounded";
import { useState } from "react";
const BinaryHuffman = ({ binaryHuffman }: BinaryHuffmanProps) => {
  const [textCopiedSuccess, setCopiedSuccess] = useState("");

  const handleCopyTextToCLipboard = async (binaryHuffmanString: string) => {
    try {
      await navigator.clipboard.writeText(binaryHuffmanString);
      setCopiedSuccess("Copié");
    } catch (error) {
      console.error(error);
      setCopiedSuccess("Echec");
    } finally {
      setTimeout(disabledCopiedSuccess, 1000);
    }
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
                <Button
                  onAnimationEnd={() =>
                    handleCopyTextToCLipboard(binaryHuffman)
                  }
                >
                  <ContentCopyRoundedIcon />
                </Button>
              </Tooltip>
            ) : (
              <span className="copy-success"> {textCopiedSuccess}</span>
            )}
          </div>
          <div className="text-break-word">{binaryHuffman}</div>
        </div>
      </div>
    </details>
  );
};
export default BinaryHuffman;
