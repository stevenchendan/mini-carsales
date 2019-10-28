import React from 'react';
import { Modal, Button } from 'antd';

export class VehicleModal extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      modal: false,
    };
  }

  render() {
    return (
      <div>
      <Modal
    title={this.props.modalHeader}
    centered
    visible={this.props.modal}
    onCancel={this.props.toggleModal}
    onOk={this.props.toggleModal}
      >
      {this.props.modalBody}
      </Modal>
      </div>
  );
}
}