import { Character } from "../../dtos/Character";
export interface DecodeFormProps {
  onDecode: (binaryHuffman: string, matchingCharacters: Character[]) => void;
}
