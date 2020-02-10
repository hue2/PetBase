import React from 'react';
import {shallow} from 'enzyme/build';
import Modal from '../views/Modal/Modal';
import renderer from 'react-test-renderer';
import Cats from '../views/Cats';

it('mounts without crashing', () => {
  const wrapper = shallow(
    <Modal 
        showModal={false} 
        title={"apple"} 
        toggle={() => {}} 
        imageUrl={"url"} 
    />);
  wrapper.unmount()
});

it('renders correctly', () => {
    const tree = renderer
      .create(<Modal 
        showModal={false} 
        title={"apple"} 
        toggle={() => {}} 
        imageUrl={"url"} 
      />)
      .toJSON();
    expect(tree).toMatchSnapshot();
});

it('modal is rendered in parent component', () => {
    const container = shallow(<Cats />)
    expect(container.find(Modal).length).toEqual(1);
});