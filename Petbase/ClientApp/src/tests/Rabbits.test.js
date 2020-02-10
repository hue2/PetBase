import React from 'react';
import {shallow} from 'enzyme/build';
import Rabbits from '../views/Rabbits';
import renderer from 'react-test-renderer';

it('mounts without crashing', () => {
  const wrapper = shallow(<Rabbits />);
  wrapper.unmount()
});

it('renders correctly', () => {
    const tree = renderer
      .create(<Rabbits />)
      .toJSON();
    expect(tree).toMatchSnapshot();
});