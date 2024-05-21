import { Button, Tooltip } from "@mui/material";
import ContentCopyRoundedIcon from "@mui/icons-material/ContentCopyRounded";
import { useState } from "react";
import { JsonModalProps } from "../Interfaces/JsonModalProps";
const JsonModal = ({ jsonString }: JsonModalProps   ) => {
  const [textCopiedSuccess, setCopiedSuccess] = useState("");

  const handleCopyTextToCLipboard = () => {
      navigator.clipboard.writeText(jsonString);
    setTimeout(disabledCopiedSuccess, 1000);
    setCopiedSuccess("Copié");
  };
  const disabledCopiedSuccess = () => {
    setCopiedSuccess("");
  };
  return (
      <div>
        <div className="notice">
          <div className="right-action-modal">
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
                  <div className="text-break-word">{jsonString}</div>
        </div>
      </div>
  );
};
export default JsonModal;
