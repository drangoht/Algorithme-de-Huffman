import { WeightedGraph } from "../../dtos/WeightedGraph";
import { Link } from "../../dtos/Link";
export interface TreeChildrenProps {
  children: Link[];
  graph: WeightedGraph;
}
