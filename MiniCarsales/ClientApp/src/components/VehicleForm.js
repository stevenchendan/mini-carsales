import React from 'react';
import {
  Form,
  Input,
  Row,
  Col,
  Button,
  Alert
} from 'antd';

export class VehicleForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      loading: false,
      warning: false,
      formData: this.props.formData
    }
  }

  onChange = (e) => {
    let newState = Object.assign({}, this.state);
    newState.formData[e.target.name] = e.target.value;
    this.setState({ newState });
  }

  showWarning = () => {
    this.setState(({
      warning: !this.state.warning
    }));
  }

  handleSubmit = e => {
    e.preventDefault();
    var formData = this.state.formData;
    let newState = Object.assign({}, this.state);
    newState.loading = true;
    this.setState(newState);
    let json = JSON.stringify(formData);
    fetch(this.props.url, {
      method: 'post',
      headers: {
        'Accept': 'application/json, text/plain, */*',
        'Content-Type': 'application/json'
      },
      body: json
    })
      .then(res => {
        if (!res.ok) {
          throw Error(res.status)
        }
        this.props.onComplete()
      })
      .catch(error => {
        this.showWarning();
        this.props.onComplete();
      })
  };

  render() {
    return (
      <Form onSubmit={this.handleSubmit}>
        <Form.Item>
          <Row>
            {
              Object.keys(this.state.formData).map((item, index) => {
                return (
                  item !== "id" && item !== "vehicleType" ? (
                    <React.Fragment >

                      <Col sm={12}>
                        <span>
                          {item.toUpperCase()}
                        </span>
                        <Input
                          className="lineSpaceInput"
                          key={index}
                          type="text"
                          name={item}
                          id={index}
                          value={this.state.formData[item]}
                          onChange={(e) => this.onChange(e)}
                        />
                      </Col>
                    </React.Fragment>
                  ) : (
                      <React.Fragment>
                        <Input
                          type="hidden"
                          name={item}
                          id={index}
                          value={this.state.formData[item]}
                          onChange={(e) => this.onChange(e)}
                        />
                      </React.Fragment>
                    )
                )
              })
            }
          </Row>
        </Form.Item>
        <Form.Item>
          <Row>
            <Col span={12}>
              <Button type="primary" htmlType="submit" className="btnSubmit" color="primary">Submit</Button>
            </Col>
          </Row>
        </Form.Item>
        {this.state.showWarning && <Alert
          message="Warning"
          description="Cannot Save Information Please Check again"
          type="error"
          closable
        />}

      </Form>

    );
  }
}