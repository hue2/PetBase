import React from 'react';
import {shallow} from 'enzyme/build';
import Cats from '../views/Cats';
import renderer from 'react-test-renderer';

it('mounts without crashing', () => {
  const wrapper = shallow(<Cats />);
  wrapper.unmount()
});

it('renders correctly', () => {
    const tree = renderer
      .create(<Cats />)
      .toJSON();
    expect(tree).toMatchSnapshot();
});