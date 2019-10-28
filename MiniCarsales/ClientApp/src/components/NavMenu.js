import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Menu, Icon } from 'antd';

const { SubMenu } = Menu;

export class NavMenu extends Component {
  state = {
    current: 'home',
  };

  handleClick = e => {
    this.setState({
      current: e.key,
    });
  };

  render() {
    return (
    <Menu onClick={this.handleClick} selectedKeys={[this.state.current]} mode="horizontal">
      <Menu.Item key="home">
      <Icon type="home" />
      <span>Home</span>
      <Link to="/" />
      </Menu.Item>
      <SubMenu
    title={
        <span className="submenu-title-wrapper">
        <Icon type="setting" />
        Create Vehicle
        </span>
      }
      >
      <Menu.ItemGroup title="Vehicles">
      <Menu.Item key="setting:1">
      <Icon type="car" />
      <span>Create Cars</span>
      <Link to="/Cars" />
      </Menu.Item>
      <Menu.Item disabled key="setting:2">
      <Icon type="lock" />
      <span>Create Boat</span>
      <Link to="/boat" />
      </Menu.Item>
      <Menu.Item disabled key="setting:3">
      <Icon type="lock" />
      <span>Create Bike</span>
      <Link to="/bike" />
      </Menu.Item>
      </Menu.ItemGroup>
      </SubMenu>
      </Menu>
  );
}
}