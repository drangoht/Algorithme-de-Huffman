import { HuffmanNode } from "./HuffmanNode";

export interface Link {
  weight: number;
  parent: HuffmanNode;
  child: HuffmanNode;
}
