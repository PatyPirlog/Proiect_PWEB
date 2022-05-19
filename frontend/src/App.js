import './App.css';
import React from 'react';
import Router from "./utils/Routing";
import Wrapper from "./utils/AuthWrapper.jsx";

const App = () => {
  return (
    <Wrapper>
      <Router />
    </Wrapper>
  );
};

export default App;
