import React from 'react';
import { Button, Modal } from 'react-bootstrap';

interface SuccessModalProps {
  show: boolean;
  message: string;
  handleClose: () => void;
}

const SuccessModal: React.FC<SuccessModalProps> = ({ show, message, handleClose }) => {
  return (
    <Modal show={show} onHide={handleClose} backdrop="static">
      <Modal.Header closeButton>
        <Modal.Title>Success</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {message}
      </Modal.Body>
      <Modal.Footer>
        <Button variant="primary" onClick={handleClose}>
          OK
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default SuccessModal;
