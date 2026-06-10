import { IconButton, Tooltip } from "@mui/material";
import ContentCopyRoundedIcon from "@mui/icons-material/ContentCopyRounded";
import CheckRoundedIcon from "@mui/icons-material/CheckRounded";
import { useState } from "react";
import { JsonModalProps } from "../../Interfaces/Encode/JsonModalProps";

const JsonModal = ({ jsonString }: JsonModalProps) => {
  const [copied, setCopied] = useState(false);

  const handleCopy = async () => {
    try {
      await navigator.clipboard.writeText(jsonString);
      setCopied(true);
      setTimeout(() => setCopied(false), 1500);
    } catch {
      // silently ignore clipboard errors
    }
  };

  return (
    <div>
      <div className="notice">
        <div className="right-action-modal">
          <Tooltip title={copied ? "Copié !" : "Copier"}>
            <IconButton size="small" onClick={handleCopy} sx={{ color: copied ? 'success.main' : undefined }}>
              {copied ? <CheckRoundedIcon fontSize="small" /> : <ContentCopyRoundedIcon fontSize="small" />}
            </IconButton>
          </Tooltip>
          {copied && <span className="copy-success">Copié</span>}
        </div>
        <div className="text-break-word">{jsonString}</div>
      </div>
    </div>
  );
};
export default JsonModal;
