import { MenuProps } from "../Interfaces/MenuProps";

const Menu: React.FC<MenuProps> = (props) => {
  const setMenu = (menuLabel: string) => {
    props.onSetMenu(menuLabel);
  };
  return (
    <div>
      <ul>
        <li>
          <button onClick={() => setMenu("encode")}> Encoder</button>
        </li>
        <li>
          <button onClick={() => setMenu("decode")}> Decoder</button>
        </li>
      </ul>
    </div>
  );
};
export default Menu;
