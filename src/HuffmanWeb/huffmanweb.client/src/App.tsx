/* eslint-disable */
import { useState } from "react";
import "./App.css";
import Encode from "./components/Encode/Encode";
import Menu from "./components/Menu";

function App() {
  const [menu, setMenu] = useState("encode");
  return (
    <div>
      <Menu onSetMenu={setMenu} />

      {menu === "encode" ? (
        <div>
          <Encode />
        </div>
      ) : (
        <div>decode</div>
      )}
    </div>
  );
}

export default App;
