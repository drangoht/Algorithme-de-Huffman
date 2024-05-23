import { DecodedTextProps } from "../../Interfaces/Decode/DecodedTextProps";

const DecodedText = ({ decodedText }: DecodedTextProps) => {
  return decodedText != "" ? (
    <details>
      <summary>Texte décodé</summary>
      <div>
        <div className="notice">
          <div className="text-break-word">{decodedText}</div>
        </div>
      </div>
    </details>
  ) : (
    <></>
  );
};
export default DecodedText;
