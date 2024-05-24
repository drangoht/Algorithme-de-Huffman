import { DecodedTextProps } from "../../Interfaces/Decode/DecodedTextProps";

const DecodedText = ({ decodedText, textNotFound }: DecodedTextProps) => {
  return decodedText != "" ? (
    <details>
      <summary>Texte décodé</summary>
      <div>
        <div className="notice">
          <div className="text-break-word">{decodedText}</div>
        </div>
      </div>
    </details>
  ) : textNotFound ? (
    <div className="error">
      Aucun texte trouvé, merci de vérifier la table de correspondance
    </div>
  ) : (
    <></>
  );
};
export default DecodedText;
