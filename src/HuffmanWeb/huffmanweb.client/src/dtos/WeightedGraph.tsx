import { HuffmanNode } from "./HuffmanNode";
import { Link } from "./Link";

export interface WeightedGraph {
  root: HuffmanNode;
  allNodes: HuffmanNode[];
  links: Link[];
}
