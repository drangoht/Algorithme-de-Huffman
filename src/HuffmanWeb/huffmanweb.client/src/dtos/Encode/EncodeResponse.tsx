import { Character } from "../Character";
import { WeightedGraph } from "../WeightedGraph";

export interface EncodeResponse {
  graph: WeightedGraph;
  matchingCharacters: Character[];
  encodedSize: number;
  originalSize: number;
  encodedBinaryString: string;
}
