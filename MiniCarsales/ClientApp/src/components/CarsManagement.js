import React, { Component } from 'react';
import { VehicleForm } from './VehicleForm';
import { VehicleModal } from './VehicleModal';
import { Table, Divider, Button } from 'antd';
import axios from 'axios';

export class CarsManagement extends Component {

  constructor(props) {
    super(props);
    this.state = {
      cars: [],
      loading: true,
      updateDialogActive: false,
      createDialogActive: false,
      selectedCar: {},
      showAlert: false,
      message: ""
    };
  }

  componentDidMount() {
    this.fetchCarsData();
  }

  fetchCarsData() {
    axios.get(`api/CarSales/GetAllCars`)
      .then(res => {
        this.setState({ cars: res.data, loading: false });
      })
      .catch(error => {
        this.showAlert(error.message)
      });
  }

  dismissAlert = () => {
    this.setState({ showAlert: false });
  }

  showAlert = (message) => {
    this.setState({
      message: message,
      showAlert: true,
      loading: false
    })
  }


  getUpdateModalProps = (formData) => {
    let props = new ModalProps();
    let formProps = this.getUpdateFormProps(formData);
    props.modalHeader = "Update Car";
    props.modalBody = <VehicleForm {...formProps}></VehicleForm>
    return props;
  }

  getCreateModalProps = () => {
    let props = new ModalProps();
    let emptyData = {
      engineType: "",
      year: "",
      numberOfWheels: "",
      numberOfDoors: "",
      make: "",
      model: "",
      bodyType: ""
    }
    let formProps = this.getCreateFormProps(emptyData);
    props.modalHeader = "Create Car";
    props.modalBody = <VehicleForm {...formProps}></VehicleForm>
    return props;
  }

  getUpdateFormProps = (formData) => {
    let formProps = new FormProps();
    formProps.formData = formData;
    formProps.url = "api/CarSales/UpdateCar";
    formProps.onComplete = () => this.closeUpdateModal();
    return formProps;
  }

  getCreateFormProps = (formData) => {
    let formProps = new FormProps();
    formProps.formData = formData;
    formProps.url = "api/CarSales/AddNewCar";
    formProps.onComplete = () => this.closeCreateModal();
    return formProps;
  }

  deleteCallBack = (id) => {
    let newState = Object.assign({}, this.state);
    newState.loading = true;
    this.setState(newState);
    axios.post(`api/CarSales/DeleteCar/${id}`)
      .then(res => {
        this.fetchCarsData()
      })
      .catch(error => {
        console.log(error.message);
      })
  }

  closeUpdateModal = () => {
    this.setState(({
      updateDialogActive: false
    }), this.fetchCarsData());
  }

  closeCreateModal = () => {
    this.setState(({
      createDialogActive: false
    }), this.fetchCarsData());
  }

  toggleUpdateModal = (car) => {
    this.setState(({
      updateDialogActive: !this.state.updateDialogActive,
      selectedCar: car
    }));
  }

  toggleCreateModal = () => {
    this.setState(({
      createDialogActive: !this.state.createDialogActive
    }));
  }


  render() {
    let updateModalProps = this.getUpdateModalProps(this.state.selectedCar);
    let createModalProps = this.getCreateModalProps();
    const vehicleFormColumns = [
      {
        title: 'Make',
        dataIndex: 'make',
        key: 'make',
        render: text => <a>{text}</a>,
      },
      {
        title: 'Model',
        dataIndex: 'model',
        key: 'model',
      },
      {
        title: 'Year',
        dataIndex: 'year',
        key: 'year',
      },
      {
        title: 'BodyType',
        dataIndex: 'bodyType',
        key: 'bodyType',
      },
      {
        title: 'NumberOfWheels',
        dataIndex: 'numberOfWheels',
        key: 'numberOfWheels',
      },
      {
        title: 'NumberOfDoors',
        dataIndex: 'numberOfDoors',
        key: 'numberOfDoors',
      },
      {
        title: 'Action',
        key: 'action',
        render: (text, record) => (
          <span>
            <Button type="primary" key={0} onClick={() => this.deleteCallBack(record.id)}>Delete</Button>
            <Divider type="vertical" />
            <Button type="primary" key={1} onClick={() => this.toggleUpdateModal(record)}>Update</Button>
          </span>
        ),
      },
    ];
    return (
      <div>
        <div className="col-sm-12">
          <h1 className="inlineHeader">
            <span>Manage Cars</span>
          </h1>
        </div>
        <Table columns={vehicleFormColumns} dataSource={this.state.cars} />
        <Button type="primary" onClick={this.toggleCreateModal}>Create new car</Button>
        <VehicleModal toggleModal={this.toggleUpdateModal} modal={this.state.updateDialogActive} {...updateModalProps} />
        <VehicleModal toggleModal={this.toggleCreateModal} modal={this.state.createDialogActive} {...createModalProps} />
      </div>
    );
  }
}

export class ModalProps {
  modalHeader = "";
  modalBody = "";
}

export class FormProps {
  formData = {};
  url = "";
  onComplete = () => { };
}