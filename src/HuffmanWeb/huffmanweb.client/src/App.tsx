/* eslint-disable */
import { useState } from "react";
import { Tabs, Tab, Box } from "@mui/material";
import "./App.css";
import Encode from "./components/Encode/Encode";
import Decode from "./components/Decode/Decode";
import SteampunkLayout from "./components/Layout/SteampunkLayout";

function App() {
  const [tab, setTab] = useState("encode");

  return (
    <SteampunkLayout>
      <div className="app-header">
        <h1>Huffman Machine</h1>
        <div className="divider-ornament"></div>
      </div>

      <Box className="app-tabs-wrapper">
        <Tabs
          value={tab}
          onChange={(_, v) => setTab(v)}
          centered
        >
          <Tab label="Encodage de texte" value="encode" />
          <Tab label="Decodage binaire" value="decode" />
        </Tabs>
      </Box>

      <div className="content-panel">
        <div className={`tab-content ${tab === "encode" ? "visible" : "hidden"}`}>
          <Encode />
        </div>
        <div className={`tab-content ${tab === "decode" ? "visible" : "hidden"}`}>
          <Decode />
        </div>
      </div>
    </SteampunkLayout>
  );
}

export default App;
