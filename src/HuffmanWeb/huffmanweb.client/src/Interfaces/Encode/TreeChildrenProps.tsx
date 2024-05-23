import { weightedGraph, link } from "../../dtos/TextToEncodeResponse";

export interface TreeChildrenProps {
  children: link[];
  graph: weightedGraph;
}
