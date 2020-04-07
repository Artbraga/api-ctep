package com.arthur.apiCTEP.services;

import com.arthur.apiCTEP.entities.Hospital;
import com.arthur.apiCTEP.repositories.HospitalRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class HospitalService extends ServiceGenerico<Hospital,Integer>{

    @Autowired
    public HospitalService(HospitalRepository repository) {
        super(repository);
    }
}
