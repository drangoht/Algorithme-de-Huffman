import { Character } from "../Character";
import { WeightedGraph } from "../WeightedGraph";

export interface textToEncodeResponse {
  graph: WeightedGraph;
  matchingCharacters: Character[];
  encodedSize: number;
  originalSize: number;
  encodedBinaryString: string;
}
