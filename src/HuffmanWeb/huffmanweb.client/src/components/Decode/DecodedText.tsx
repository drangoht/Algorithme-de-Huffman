import { Accordion, AccordionSummary, AccordionDetails, Alert } from "@mui/material";
import ExpandMoreRoundedIcon from "@mui/icons-material/ExpandMoreRounded";
import { DecodedTextProps } from "../../Interfaces/Decode/DecodedTextProps";

const DecodedText = ({ decodedText, textNotFound }: DecodedTextProps) => {
  if (decodedText) {
    return (
      <Accordion defaultExpanded sx={{ animation: 'cardIn 0.4s ease both', '@keyframes cardIn': { from: { opacity: 0, transform: 'translateY(8px)' }, to: { opacity: 1, transform: 'translateY(0)' } } }}>
        <AccordionSummary expandIcon={<ExpandMoreRoundedIcon />}>
          Texte décodé
        </AccordionSummary>
        <AccordionDetails>
          <div className="notice">
            <div className="text-break-word" style={{ color: '#34D399', fontFamily: 'var(--font-ui)', fontSize: '1rem', fontWeight: 500 }}>
              {decodedText}
            </div>
          </div>
        </AccordionDetails>
      </Accordion>
    );
  }

  if (textNotFound) {
    return (
      <Alert severity="warning" sx={{ mt: 1 }}>
        Aucun texte trouvé — vérifiez la table de correspondance.
      </Alert>
    );
  }

  return null;
};
export default DecodedText;
