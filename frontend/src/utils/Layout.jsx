import React from "react";
import Header from "./Header";

const Layout = ({ children }) => {

  return (
    <div className="user-layout">
      <Header />
      <div className="user-content">{children}</div>
    </div>
  );
};

export default Layout;
