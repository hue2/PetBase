import React from 'react';
import {shallow} from 'enzyme/build';
import Dogs from '../views/Dogs';
import renderer from 'react-test-renderer';

it('mounts without crashing', () => {
  const wrapper = shallow(<Dogs />);
  wrapper.unmount()
});

it('renders correctly', () => {
    const tree = renderer
      .create(<Dogs />)
      .toJSON();
    expect(tree).toMatchSnapshot();
});