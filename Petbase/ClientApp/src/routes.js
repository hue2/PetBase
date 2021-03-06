import React from 'react';

const Cats = React.lazy(() => import('./views/Cats'));
const Dogs = React.lazy(() => import('./views/Dogs'));
const Rabbits = React.lazy(() => import('./views/Rabbits'));

// https://github.com/ReactTraining/react-router/tree/master/packages/react-router-config
const routes = [
  { path: '/cats', name: "Cats", component: Cats },
  { path: '/dogs', name: "Dogs", component: Dogs },
  { path: '/rabbits', name: "Rabbits", component: Rabbits }
];

export default routes;
