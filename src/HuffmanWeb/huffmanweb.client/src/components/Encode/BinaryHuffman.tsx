import { Accordion, AccordionSummary, AccordionDetails, IconButton, Tooltip } from "@mui/material";
import ExpandMoreRoundedIcon from "@mui/icons-material/ExpandMoreRounded";
import ContentCopyRoundedIcon from "@mui/icons-material/ContentCopyRounded";
import CheckRoundedIcon from "@mui/icons-material/CheckRounded";
import { useState } from "react";
import { BinaryHuffmanProps } from "../../Interfaces/Encode/BinaryHuffmanProps";

const BinaryHuffman = ({ binaryHuffman }: BinaryHuffmanProps) => {
  const [copied, setCopied] = useState(false);

  if (!binaryHuffman) return null;

  const handleCopy = async () => {
    try {
      await navigator.clipboard.writeText(binaryHuffman);
      setCopied(true);
      setTimeout(() => setCopied(false), 1500);
    } catch {
      // silently ignore clipboard errors
    }
  };

  return (
    <Accordion defaultExpanded>
      <AccordionSummary expandIcon={<ExpandMoreRoundedIcon />}>
        Résultat binaire
      </AccordionSummary>
      <AccordionDetails>
        <div className="notice">
          <div className="right-action">
            <Tooltip title={copied ? "Copié !" : "Copier"}>
              <IconButton size="small" onClick={handleCopy} sx={{ color: copied ? 'success.main' : undefined }}>
                {copied ? <CheckRoundedIcon fontSize="small" /> : <ContentCopyRoundedIcon fontSize="small" />}
              </IconButton>
            </Tooltip>
            {copied && <span className="copy-success">Copié</span>}
          </div>
          <div className="text-break-word">{binaryHuffman}</div>
        </div>
      </AccordionDetails>
    </Accordion>
  );
};
export default BinaryHuffman;
