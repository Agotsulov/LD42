package com.ld42.game.ecs.scenes;

import com.ld42.game.ecs.core.Engine;
import com.ld42.game.ecs.core.Entity;
import com.ld42.game.ecs.core.Scene;

import java.util.ArrayList;
import java.util.List;

public class ArrayListScene extends Scene{

    private List<Entity> entities;

    public ArrayListScene(Engine engine, String name) {
        super(engine, name);
        entities = new ArrayList<>();
    }

    @Override
    public boolean add(Entity o) {
        return entities.add(o);
    }

    @Override
    public boolean contains(Entity o) {
        return entities.contains(o);
    }

    @Override
    public boolean remove(Entity o) {
        return entities.remove(o);
    }

    @Override
    public int size() {
        return entities.size();
    }

    @Override
    public Entity get(int i) {
        return entities.get(i);
    }
}
